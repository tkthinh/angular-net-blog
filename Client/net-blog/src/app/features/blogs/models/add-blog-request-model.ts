export interface AddBlogModel {
  title: string;
  shortDescription: string;
  content: string;
  thumbnailUrl: string;
  slug: string;
  author: string;
  publishedDate: Date;
  isVisible: boolean;
}
