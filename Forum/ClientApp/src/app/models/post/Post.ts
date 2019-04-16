import { Author } from '../user/Author';
import { RepliedPost } from './RepliedPost';

export interface Post{
    id: number,
    content: string,
    postDate: Date,
    userProfile: Author,
    repliedPost: RepliedPost
}