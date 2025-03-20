import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { format } from 'date-fns';
import { tr } from 'date-fns/locale';
import Link from 'next/link';

interface BlogPost {
    portfolioBlogId: number;
    title: string;
    subContent: string;
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

const BlogList = () => {
    const [blogs, setBlogs] = useState<BlogPost[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const fetchBlogs = async () => {
            try {
                const response = await axios.get('https://localhost:7152/api/PortfolioBlogs');
                setBlogs(response.data);
                setLoading(false);
            } catch (err) {
                setError('Blog yazıları yüklenirken bir hata oluştu.');
                setLoading(false);
            }
        };

        fetchBlogs();
    }, []);

    if (loading) return <div>Yükleniyor...</div>;
    if (error) return <div>{error}</div>;

    return (
        <div className="container mx-auto px-4 py-8">
            <h1 className="text-3xl font-bold mb-8">Blog Yazıları</h1>
            <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
                {blogs.map((blog) => (
                    <div key={blog.portfolioBlogId} className="bg-white rounded-lg shadow-lg overflow-hidden">
                        <img 
                            src={blog.coverImage} 
                            alt={blog.title}
                            className="w-full h-48 object-cover"
                        />
                        <div className="p-6">
                            <div className="flex flex-wrap gap-2 mb-3">
                                {blog.portfolioBlogCategories.map((category) => (
                                    <span 
                                        key={category.blogCategoryId}
                                        className="bg-blue-100 text-blue-800 text-xs font-medium px-2.5 py-0.5 rounded"
                                    >
                                        {category.categoryName}
                                    </span>
                                ))}
                            </div>
                            <h2 className="text-xl font-semibold mb-2">{blog.title}</h2>
                            <p className="text-gray-600 mb-4">{blog.subContent}</p>
                            <div className="flex flex-wrap gap-2 mb-4">
                                {blog.portfolioBlogTags.map((tag) => (
                                    <span 
                                        key={tag.portfolioBlogTagId}
                                        className="bg-gray-100 text-gray-800 text-xs font-medium px-2.5 py-0.5 rounded"
                                    >
                                        {tag.tagName}
                                    </span>
                                ))}
                            </div>
                            <div className="flex justify-between items-center">
                                <span className="text-sm text-gray-500">
                                    {format(new Date(blog.publishDate), 'dd MMMM yyyy', { locale: tr })}
                                </span>
                                <Link 
                                    href={`/blog/${blog.portfolioBlogId}`}
                                    className="text-blue-600 hover:text-blue-800"
                                >
                                    Devamını Oku →
                                </Link>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default BlogList; 