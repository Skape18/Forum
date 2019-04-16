import { Author } from '../user/Author';

export interface Thread{
    id: number,
    title: string,
    content: string,
    isOpen: boolean,
    threadOpenedDate: Date,
    postsNumber: number,
    userProfile: Author
}