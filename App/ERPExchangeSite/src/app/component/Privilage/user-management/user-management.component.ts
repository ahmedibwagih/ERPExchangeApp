import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { BackEndClientService } from 'src/app/services/back-end-client.service';
import { UserDto, UserDtoPagingResultDto } from 'src/app/services/api.service';
@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.scss']
})
export class UserManagementComponent implements OnInit {

  users: UserDto[] = [];
  user: UserDto = new UserDto();
  userService:BackEndClientService;
  constructor(private back:BackEndClientService) { 
    this.userService = back;

  }
  displayedColumns = ['userName', 'fullName', 'email' , 'phoneNumber' , 'actions'];

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(){
debugger;
    this.back.authenticationGetUsers()
    .then((result: UserDtoPagingResultDto) => {
      this.users = result?.result ?? [];
      })
    .catch((error) => {
      console.error('Error fetching data:', error);
    });

  }

  

  addUser(user: UserDto): void {
    // this.userService.addUser(user).subscribe(() => {
    //   this.loadUsers();
    // });
  }

  editUser(user: UserDto): void {
  //   this.userService.editUser(user).subscribe(() => {
  //     this.loadUsers();
  //   });
   }

  deleteUser(userId: string): void {
    // this.userService.deleteUser(userId).subscribe(() => {
    //   this.loadUsers();
    // });
  }

  submitForm(): void {
    // Submit logic here
    if (this.user.id) {
      // Edit existing user logic
    } else {
      // Add new user logic
      // Example:
      // this.http.post<UserDto>('your-api-url', this.user)
      //   .subscribe(newUser => {
      //     this.users.push(newUser);
      //     this.user = new UserDto(); // Clear form after submission
      //   });
    }
  }
}