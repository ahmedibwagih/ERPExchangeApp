import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { BackEndClientService } from 'src/app/services/back-end-client.service';
import { UserDto } from 'src/app/services/api.service';
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
  displayedColumns = ['UserName', 'Email', 'FullName', 'actions'];

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    // this.userService.getUsers().subscribe(users => {
    //   this.users = users;
    // });
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