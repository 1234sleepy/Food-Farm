export interface Comment {
    id: string;
    commentId: string;
    productId: string;
    comments: Comment[] | null;
    name: string;
    phone: string;
    text: string;
    totalComments: number;
    rating: number;
    like: number;
    dislike: number;
    createdAt: Date;
    userId: string | null;
}