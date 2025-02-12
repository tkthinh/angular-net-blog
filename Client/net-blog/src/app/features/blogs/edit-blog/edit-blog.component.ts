import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatOptionModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule, MatLabel } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ActivatedRoute, Router } from '@angular/router';
import { MarkdownModule } from 'ngx-markdown';
import { Observable } from 'rxjs';
import { Category } from '../../categories/models/category.model';
import { CategoryService } from '../../categories/services/category.service';
import { Blog } from '../models/blog-model';
import { BlogService } from '../services/blog.service';

@Component({
  selector: 'app-edit-blog',
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MarkdownModule,
    MatLabel,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatOptionModule,
    MatDatepickerModule,
    MatCheckboxModule,
    MatButtonModule,
  ],
  templateUrl: './edit-blog.component.html',
  styleUrl: './edit-blog.component.css',
})
export class EditBlogComponent {
  blogForm: FormGroup;
  categories$?: Observable<Category[]>;
  blogId!: string; // ID of the blog to edit
  blog!: Blog; // Holds the fetched blog data

  constructor(
    private fb: FormBuilder,
    private blogService: BlogService,
    private categoryService: CategoryService,
    private router: Router,
    private route: ActivatedRoute,
  ) {
    this.blogForm = this.fb.group({
      title: ['', [Validators.required, Validators.minLength(3)]],
      slug: [
        '',
        [Validators.required, Validators.pattern('^[a-z0-9]+(?:-[a-z0-9]+)*$')],
      ],
      shortDescription: ['', [Validators.required, Validators.minLength(10)]],
      content: ['', [Validators.required, Validators.minLength(20)]],
      thumbnailUrl: ['', [Validators.required]],
      publishDate: ['', [Validators.required]],
      author: ['', [Validators.required]],
      isPublished: [false],
      category: ['', Validators.required],
    });
  }

  ngOnInit(): void {
    // Get the blog ID from the route parameter
    this.blogId = this.route.snapshot.paramMap.get('id')!;

    // Fetch the blog data
    this.blogService.getBlogById(this.blogId).subscribe({
      next: (blog) => {
        this.blog = blog;
        console.log('Blog:', blog);
        this.blogForm.patchValue({
          title: blog.title,
          slug: blog.slug,
          shortDescription: blog.shortDescription,
          content: blog.content,
          thumbnailUrl: blog.thumbnailUrl,
          publishDate: blog.publishedDate
            ? new Date(blog.publishedDate).toISOString().split('T')[0]
            : '', // Format the date as yyyy-mm-dd
          author: blog.author,
          isPublished: blog.isPublished, // This may need mapping if the value is different
          category: blog.categories.map(cat => cat.id), // Assuming you want to preselect the first category
        });
      },
      error: (err) => {
        console.error('Error fetching blog:', err);
      },
    });

    // Fetch categories from the API
    this.categories$ = this.categoryService.getAllCategories();
  }

  onUpdate(): void {
    if (this.blogForm.valid) {
      const updatedBlog: Blog = { ...this.blog, ...this.blogForm.value };

      this.blogService.updateBlog(this.blogId, updatedBlog).subscribe({
        next: () => {
          this.router.navigate(['/blogs']); // Redirect to blog list after update
        },
        error: (err) => {
          console.error('Error updating blog:', err);
        },
      });
    }
  }

  onDelete(): void {
    if (confirm('Are you sure you want to delete this blog?')) {
      this.blogService.deleteBlog(this.blogId).subscribe({
        next: () => {
          this.router.navigate(['/blogs']); // Redirect to blog list after deletion
        },
        error: (err) => {
          console.error('Error deleting blog:', err);
        },
      });
    }
  }

  navigateToBlogs(): void {
    this.router.navigate(['/admin/blogs']);
  }
}
