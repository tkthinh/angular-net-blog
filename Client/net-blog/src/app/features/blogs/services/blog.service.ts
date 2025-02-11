import { Injectable } from '@angular/core';
import { AddBlogModel } from '../models/add-blog-model';
import { Blog } from '../models/blog-model';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment.development';

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


}
