import { Component, OnInit } from '@angular/core';

import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { RouterLink } from '@angular/router';
import { Blog } from '../models/blog-model';
import { BlogService } from '../services/blog.service';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-index-blog',
  imports: [
    CommonModule,
    MatCardModule,
    MatTableModule,
    MatButtonModule,
    RouterLink,
  ],
  templateUrl: './index-blog.component.html',
  styleUrls: ['./index-blog.component.css'],
})
export class IndexBlogComponent implements OnInit {
  blogs$?: Observable<Blog[]>;
  displayedColumns: string[] = ['id', 'title', 'author', 'categories', 'isPublished', 'actions'];

  constructor(private blogService: BlogService) {}

  ngOnInit(): void {
    this.blogs$ = this.blogService.getBlogs();
  }
}
