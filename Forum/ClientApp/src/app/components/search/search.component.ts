import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import { User } from '../../models/user/User';
import {UserService} from "../../services/user/user/user.service";

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  searchResult: User[] = [];
  @ViewChild('searchInput') nameInput: ElementRef;
  constructor(private userService: UserService) {
  }

  ngOnInit() {
    // this.searchResult.push({
    //   id: 1,
    //   profileImagePath: 'profile_images/default_profile_image.png',
    //   rating: 5,
    //   isActive: true,
    //   registrationDate: new Date(),
    //   userName: 'TestUser1',
    //   description: 'Seven years of experience in multiple projects as a Java Engineer. Experience with high-loaded production live projects. Six years of work with micro-services cloud platforms. Able to lead a team and take responsibility for major features development.',
    //   email: 'testuser@emal.com',
    //   tags: [
    //     {id: 1, name: 'Java'} as Tag,
    //     {id: 2, name: 'MongoDb'} as Tag,
    //     {id: 3, name: 'PostreSql'} as Tag,
    //     {id: 4, name: 'Spring'} as Tag,
    //     {id: 5, name: 'Kafka'} as Tag,
    //     {id: 6, name: 'JDBC'} as Tag,
    //   ]
    // } as User);
    //
    // this.searchResult.push({
    //   id: 1,
    //   profileImagePath: 'profile_images/default_profile_image.png',
    //   rating: 5,
    //   isActive: true,
    //   registrationDate: new Date(),
    //   userName: 'TestUser2',
    //   description: 'A Java software engineer with 5+ years of experience in building software products with a scalable and distributed architecture that are easy to evolve and maintain to serve millions of users and make a significant impact on their daily life. Proficient at developing backend tasks such as Rest API, systems integration, reactive systems, micro-services designing, cloud architectures, and services maintenance. I have worked with multiple frameworks, software, and programming languages.',
    //   email: 'testuser2@emal.com',
    //   tags: [
    //     {id: 2, name: 'MongoDb'} as Tag,
    //     {id: 3, name: 'PostreSql'} as Tag,
    //     {id: 4, name: 'Spring'} as Tag,
    //     {id: 5, name: 'Kafka'} as Tag,
    //     {id: 6, name: 'JDBC'} as Tag,
    //   ]
    // } as User);
  }

  search() {
    const value = this.nameInput.nativeElement.value;
    if (value.length >= 3){
      this.userService.search(value)
        .subscribe(r => {
          console.log(r);
          this.searchResult = r
        });
    }
  }
  getUserTags(user: User){
    return user.tags.map(t => t.name).join(', ');
  }
}
