export class PostCreate{
    content: string;
    userProfileId: number;
    threadId: number;
    repliedPostId? : number;

    constructor(content: string, userProfileId: number, threadId: number, repliedPostId?: number){
        this.content = content;
        this.userProfileId = userProfileId;
        this.threadId = threadId;
        this.repliedPostId = repliedPostId;
    }
}