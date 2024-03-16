import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { BackEndClientService } from 'src/app/services/back-end-client.service';
import { JobsDto, JobsDtoPagingResultDto, UserDto, UserDtoPagingResultDto } from 'src/app/services/api.service';
import { PublicClsService } from 'src/app/services/public-cls.service';
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
  isEditing = false;
  constructor(public PublicClsService:PublicClsService,private back:BackEndClientService) { 
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
    this.PublicClsService.CheckQuery('users');
   

     //fill jobs
     this.back.jobsGetAll(1,10000,'id',undefined,undefined,undefined)
     .then((result: JobsDtoPagingResultDto) => {
       this.jobsOptions = result.result?? [];
       this.loadUsers();
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
      this.user= new UserDto();
      })
    .catch((error) => {
      console.error('Error fetching data:', error);
    });

  }

  

  createUser(): void {
    if (this.isEditing==true)
    {
      this.back.authenticationUpdateUser(this.user) .then(() => {
        this.loadUsers();
        this.alert( "تم التعديل بنجاح","success");
         })
      .catch((error) => {
        debugger;
        var message = error.response.split(':')[1].split('.')[0];
         console.error('Error fetching data:', error);
         if(message)
           this.alert( message,"danger");
          else
          this.alert( "حدث خطا اثناء التعديل","danger");
      });
      
    }else
    {
   
      this.back.authenticationCreateUser(this.user) .then(() => {
      this.loadUsers();
      this.alert( "تم الاضافة بنجاح","success");
       })
    .catch((error) => {
      debugger;
      var message = error.response.split(':')[1].split('.')[0];
       console.error('Error fetching data:', error);
       if(message)
       this.alert( message,"danger");
      else
      this.alert( "حدث خطا اثناء الاضافة","danger");
    });

  }


  }

  editUser(user: UserDto): void {
debugger;
// if (this.setJobid == 0)
// return;
//user.jobId=this.setJobid ;
this.isEditing=true;
 user.password ="P@$$w0rd";
 if (user.fullName== null)
 user.fullName =" ";

    this.user = user;
    // this.back.authenticationUpdateUser(this.user) .then(() => {
      
    //   this.alert( "تم التعديل بنجاح","success");
    // })
    // .catch((error) => {
    //   console.error('Error fetching data:', error);
    //   this.alert( "يوجد مشكله في التعديل","warning");
    // });
    // this.setJobid = 0;
   }

  deleteUser(userId: string): void {
    debugger;
    this.back.authenticationUpdateDelete(userId) .then(() => {
      this.loadUsers();
      this.alert( "تم الحذف بنجاح","success");
       })
    .catch((error) => {
        this.alert( "حدث خطا اثناء الحذف","danger");
    });
    
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