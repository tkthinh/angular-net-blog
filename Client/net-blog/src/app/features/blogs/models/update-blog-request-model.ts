export interface UpdateBlogModel {
  title: string;
  shortDescription: string;
  content: string;
  thumbnailUrl: string;
  slug: string;
  author: string;
  publishedDate: Date;
  isPublished: boolean;
}
