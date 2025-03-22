using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogDtos;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogServices;
using System.Reflection;
using System.Web;
using System.Net;
using Newtonsoft.Json;
using Portfolio.WebUI.Services.PortfolioServices.PortfolioBlogTagServices;
using Portfolio.WebUI.Models;
using Portfolio.DtoLayer.PortfolioDtos.PortfolioBlogTagDtos;
using Microsoft.AspNetCore.Authorization;
using Portfolio.WebUI.Services.PortfolioServices.BlogCategoryServices;
using Portfolio.WebUI.Services.ImageUploadServices.ImageUploadServices;

namespace Portfolio.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/PortfolioBlog")]
    [Authorize]
    public class PortfolioBlogController : Controller
    {
        private readonly IPortfolioBlogService _portfolioBlogService;
        private readonly IPortfolioBlogTagServices _portfolioBlogTagService;
        private readonly IBlogCategoryService _blogCategoryService;
        private readonly IImageUploadService _imageUploadService;

        public PortfolioBlogController(IPortfolioBlogService portfolioBlogService, IPortfolioBlogTagServices portfolioBlogTagService, IBlogCategoryService blogCategoryService, IImageUploadService imageUploadService)
        {
            _portfolioBlogService = portfolioBlogService;
            _portfolioBlogTagService = portfolioBlogTagService;
            _blogCategoryService = blogCategoryService;
            _imageUploadService = imageUploadService;
        }

        [HttpGet]
        [Route("GetAllPortfolioBlog")]
        public async Task<IActionResult> GetAllPortfolioBlog()
        {
            var values = await _portfolioBlogService.GetAllPortfolioBlogAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreatePortfolioBlog")]
        public async Task<IActionResult> CreatePortfolioBlog()
        {
            var tags = await _portfolioBlogTagService.GetAllPortfolioBlogTagAsync();
            var categories = await _blogCategoryService.GetAllPortfolioBlogCategoryAsync();
            var model = new BlogTagsViewModel
            {   
                BlogTags = tags,
                BlogCategories = categories,
                BlogCreate = new CreatePortfolioBlogDto()
            };
            return View(model);
        }

        [HttpPost]
        [Route("CreatePortfolioBlog")]
        public async Task<IActionResult> CreatePortfolioBlog([FromForm] CreatePortfolioBlogDto createPortfolioBlogDto, IFormFile image, [FromForm] string tagIds, [FromForm] string categoryIds)
        {
            try
            {
                if (createPortfolioBlogDto == null)
                {
                    return Json(new { success = false, message = "Blog verisi boş olamaz." });
                }

                if (image != null)
                {
                    createPortfolioBlogDto.CoverImage = await _imageUploadService.UploadImageAsync(image);
                }

                // Tag ve kategori ID'lerini parse et
                if (!string.IsNullOrEmpty(tagIds))
                {
                    createPortfolioBlogDto.TagIds = JsonConvert.DeserializeObject<List<int>>(tagIds);
                }
                if (!string.IsNullOrEmpty(categoryIds))
                {
                    createPortfolioBlogDto.CategoryIds = JsonConvert.DeserializeObject<List<int>>(categoryIds);
                }

                // Blog'u oluştur
                var result = await _portfolioBlogService.CreatePortfolioBlogAsync(createPortfolioBlogDto);
                
                return Json(new { 
                    success = true, 
                    redirectToUrl = Url.Action("GetAllPortfolioBlog", "PortfolioBlog", new { area = "Admin" }) 
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        [Route("UpdatePortfolioBlog/{id}")]
        public async Task<IActionResult> UpdatePortfolioBlog(int id)
        {
            var blog = await _portfolioBlogService.GetPortfolioBlogByPortfolioBlogIdAsync(id);
            var allTags = await _portfolioBlogTagService.GetAllPortfolioBlogTagAsync();
            var allCategories = await _blogCategoryService.GetAllPortfolioBlogCategoryAsync();

            var model = new BlogTagsViewModel
            {
                BlogTags = allTags,
                BlogCategories = allCategories,
                BlogUpdate = blog
            };

            return View(model);
        }

        [HttpPost]
        [Route("UpdatePortfolioBlog/{id}")]
        public async Task<IActionResult> UpdatePortfolioBlog([FromForm] UpdatePortfolioBlogDto updatePortfolioBlogDto, IFormFile image, [FromForm] string tagIds, [FromForm] string categoryIds)
        {
            try
            {
                if (updatePortfolioBlogDto == null)
                {
                    return Json(new { success = false, message = "Blog verisi boş olamaz." });
                }

                // Mevcut blog verisini al
                var existingBlog = await _portfolioBlogService.GetPortfolioBlogByPortfolioBlogIdAsync(updatePortfolioBlogDto.PortfolioBlogId);
                if (existingBlog == null)
                {
                    return Json(new { success = false, message = "Blog bulunamadı." });
                }

                // Resim işlemi
                if (image != null && image.Length > 0)
                {
                    try
                    {
                        // Resim uzantısını kontrol et
                        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                        var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();
                        
                        if (!allowedExtensions.Contains(fileExtension))
                        {
                            return Json(new { success = false, message = "Sadece .jpg, .jpeg, .png ve .gif formatları desteklenmektedir." });
                        }

                        // Resim boyutunu kontrol et (max 5MB)
                        if (image.Length > 5 * 1024 * 1024)
                        {
                            return Json(new { success = false, message = "Resim boyutu 5MB'dan büyük olamaz." });
                        }

                        var updatedImage = await _imageUploadService.UploadImageAsync(image);
                        updatePortfolioBlogDto.CoverImage = updatedImage;
                    }
                    catch (Exception ex)
                    {
                        return Json(new { success = false, message = "Resim yükleme hatası: " + ex.Message });
                    }
                }
                else
                {
                    // Mevcut resmi koru
                    updatePortfolioBlogDto.CoverImage = existingBlog.CoverImage;
                }

                // Tag ve kategori ID'lerini parse et
                try
                {
                    if (!string.IsNullOrEmpty(tagIds))
                    {
                        updatePortfolioBlogDto.TagIds = JsonConvert.DeserializeObject<List<int>>(tagIds);
                    }
                    if (!string.IsNullOrEmpty(categoryIds))
                    {
                        updatePortfolioBlogDto.CategoryIds = JsonConvert.DeserializeObject<List<int>>(categoryIds);
                    }
                }
                catch (JsonException ex)
                {
                    return Json(new { success = false, message = "Tag veya kategori verilerinde hata: " + ex.Message });
                }

                await _portfolioBlogService.UpdatePortfolioBlogAsync(updatePortfolioBlogDto);
                
                return Json(new { 
                    success = true, 
                    redirectToUrl = Url.Action("GetAllPortfolioBlog", "PortfolioBlog", new { area = "Admin" }) 
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Güncelleme sırasında bir hata oluştu: " + ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Route("DeletePortfolioBlog/{id}")]
        public async Task<IActionResult> DeletePortfolioBlog(int id)
        {
            await _portfolioBlogService.DeletePortfolioBlogAsync(id);
            return RedirectToAction("GetAllPortfolioBlog", "PortfolioBlog", new { area = "Admin" });
        }
    }
}
