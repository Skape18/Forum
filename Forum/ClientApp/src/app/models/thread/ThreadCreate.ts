export class ThreadCreate {
  title: string;
  content: string;
  userProfileId: number;
  topicId: number;

  constructor(title: string, content: string, profileUserId: number, topicId: number) {
    this.title = title;
    this.content = content;
    this.userProfileId = profileUserId;
    this.topicId = topicId;    
  }
}
