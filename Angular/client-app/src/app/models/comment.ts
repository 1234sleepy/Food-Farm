export interface Comment {
    id: string;
    commentId: string;
    productId: string;
    comments: Comment[] | null;
    name: string;
    phone: string;
    text: string;
    rating: number;
    like: number;
    dislike: number;
    createdAt: Date;
    userId: string | null;
}