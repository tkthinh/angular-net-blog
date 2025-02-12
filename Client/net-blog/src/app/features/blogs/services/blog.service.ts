import { Injectable } from '@angular/core';
import { AddBlogModel } from '../models/add-blog-request-model';
import { Blog } from '../models/blog-model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment.development';
import { UpdateBlogModel } from '../models/update-blog-request-model';

@Injectable({
  providedIn: 'root'
})
export class BlogService {

  constructor(private http: HttpClient) { }

  createBlog(data: AddBlogModel): Observable<Blog> {
    return this.http.post<Blog>(`${environment.apiUrl}/posts`, data);
  }

  getBlogs(): Observable<Blog[]> {
    return this.http.get<Blog[]>(`${environment.apiUrl}/posts`);
  }

  getBlogById(id: string): Observable<Blog> {
    return this.http.get<Blog>(`${environment.apiUrl}/posts/${id}`);
  }

  updateBlog(id: string, data: UpdateBlogModel): Observable<Blog> {
    return this.http.put<Blog>(`${environment.apiUrl}/posts/${id}`, data);
  }

  deleteBlog(id: string): Observable<Blog> {
    return this.http.delete<Blog>(`${environment.apiUrl}/posts/${id}`);
  }

}
