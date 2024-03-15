import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { BackEndClientService } from 'src/app/services/back-end-client.service';
import { JobsDto, JobsDtoPagingResultDto, UserDto, UserDtoPagingResultDto } from 'src/app/services/api.service';
@Component({
  selector: 'app-user-management',
  templateUrl: './user-management.component.html',
  styleUrls: ['./user-management.component.scss']
})
export class UserManagementComponent implements OnInit {
  //alert
 // danger-warning-success-info
 showAlert: boolean = false;
 alertMessage: any = false;
 alertType: any = false;
 onCloseAlert() {
   this.showAlert = false;
   this.alertMessage  ="" ;
   this.alertType ="" ;
 }
 alert(message: any,type: any)
 {
  debugger;
 this.alertMessage  =message ;
 this.alertType =type ;
 this.showAlert = true;
 }
////////////////////////////////////
  users: UserDto[] = [];
  user: UserDto = new UserDto();
  userService:BackEndClientService;
  jobsOptions!: JobsDto[];
  setJobid:number=0;
  constructor(private back:BackEndClientService) { 
    this.userService = back;

  }
  displayedColumns = ['userName', 'fullName', 'email' , 'phoneNumber' ,'JobId', 'actions'];

  onSelectionChange(value: any) {
    debugger;
    //const selectedValue = parseInt((value.target as HTMLSelectElement).value,10);
    const selectedValue =value.value;
    this.setJobid =  selectedValue;
 
  //  console.log('Selected option:', value);
    // Handle selection change logic here
  }

  ngOnInit(): void {
    this.loadUsers();

     //fill jobs
     this.back.jobsGetAll(1,100,undefined,undefined,undefined,undefined)
     .then((result: JobsDtoPagingResultDto) => {
       this.jobsOptions = result.result?? [];
 
     })
     .catch((error) => {
       console.error('Error fetching data:', error);
     });

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
debugger;
if (this.setJobid == 0)
return;
user.jobId=this.setJobid ;
 user.password ="";
 if (user.fullName== null)
 user.fullName =" ";

    this.user = user;
    this.back.authenticationUpdateUser(this.user) .then(() => {
      
      this.alert( "تم التعديل بنجاح","success");
    })
    .catch((error) => {
      console.error('Error fetching data:', error);
      this.alert( "يوجد مشكله في التعديل","warning");
    });

    this.setJobid = 0;
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