import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { format } from 'date-fns';
import { tr } from 'date-fns/locale';

interface BlogPost {
    portfolioBlogId: number;
    title: string;
    content: string;
    coverImage: string;
    publishDate: string;
    portfolioBlogTags: {
        portfolioBlogTagId: number;
        tagName: string;
    }[];
    portfolioBlogCategories: {
        blogCategoryId: number;
        categoryName: string;
    }[];
}

interface BlogDetailProps {
    blogId: number;
}

const BlogDetail: React.FC<BlogDetailProps> = ({ blogId }) => {
    const [blog, setBlog] = useState<BlogPost | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchBlogDetail = async () => {
            try {
                const response = await axios.get(`https://localhost:7152/api/PortfolioBlogs/${blogId}`);
                setBlog(response.data);
                setLoading(false);
            } catch (err) {
                setError('Blog detayları yüklenirken bir hata oluştu.');
                setLoading(false);
            }
        };

        fetchBlogDetail();
    }, [blogId]);

    if (loading) return <div>Yükleniyor...</div>;
    if (error) return <div>{error}</div>;
    if (!blog) return <div>Blog bulunamadı.</div>;

    return (
        <article className="container mx-auto px-4 py-8 max-w-4xl">
            <img 
                src={blog.coverImage}
                alt={blog.title}
                className="w-full h-96 object-cover rounded-lg shadow-lg mb-8"
            />
            <div className="flex flex-wrap gap-2 mb-4">
                {blog.portfolioBlogCategories.map((category) => (
                    <span 
                        key={category.blogCategoryId}
                        className="bg-blue-100 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded"
                    >
                        {category.categoryName}
                    </span>
                ))}
            </div>
            <h1 className="text-4xl font-bold mb-4">{blog.title}</h1>
            <div className="text-gray-500 mb-6">
                {format(new Date(blog.publishDate), 'dd MMMM yyyy', { locale: tr })}
            </div>
            <div 
                className="prose prose-lg max-w-none"
                dangerouslySetInnerHTML={{ __html: blog.content }}
            />
            <div className="mt-8 pt-6 border-t">
                <div className="flex flex-wrap gap-2">
                    {blog.portfolioBlogTags.map((tag) => (
                        <span 
                            key={tag.portfolioBlogTagId}
                            className="bg-gray-100 text-gray-800 text-sm font-medium px-3 py-1 rounded"
                        >
                            #{tag.tagName}
                        </span>
                    ))}
                </div>
            </div>
        </article>
    );
};

export default BlogDetail; 