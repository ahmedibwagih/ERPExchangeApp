import { Component, OnInit, ViewChild  } from '@angular/core';
import { JobsDto, JobsDtoPagingResultDto, PrivilageDto, PrivilageDtoPagingResultDto, PrivilageTypeDto, PrivilageTypeDtoPagingResultDto, ScreensDto, ScreensDtoPagingResultDto } from 'src/app/services/api.service';
import { BackEndClientService } from 'src/app/services/back-end-client.service';
import { GenericAlertComponent } from '../../General/generic-alert/generic-alert.component';
import { PublicClsService } from 'src/app/services/public-cls.service';

@Component({
  selector: 'app-privilages',
  templateUrl: './privilage.component.html',
  styleUrls: ['./privilage.component.scss']
})

export class PrivilagesComponent implements OnInit {
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
  stateOptions = [         
    { value: 0, viewValue: 'Deny' },
    { value: 1, viewValue: 'Allow' }
  ];
  Allprivilages:PrivilageDtoPagingResultDto | undefined ;
  Allpriv: PrivilageDto[]  = [];
  privilages: PrivilageDto[]  = [];
  privilage: PrivilageDto = new PrivilageDto()  ;

currentjob:any;
  jobsOptions!: JobsDto[];
  ScreensOptions!: ScreensDto[];
  PrivilageTypesOptions!: PrivilageTypeDto[];


  
  isEditing = false;
  displayedColumns = ['JobId', 'ScreensId', 'PrivilageTypeId','State'];

  backend:BackEndClientService;
  constructor(public PublicClsService:PublicClsService,private back:BackEndClientService) { 
    this.backend = back;

  }

  setVal(value: PrivilageDto) {
    debugger;
    if (value.state ==0)
    value.state =1;
  else
  value.state =0;
    this.editPrivilage(value);
  }
  onSelectionChange(value: any) {
    debugger;
  

    //const selectedValue = parseInt((value.target as HTMLSelectElement).value,10);
    const selectedValue =value.value;
    this.privilages =  this.Allpriv.filter(a=>a.jobId == selectedValue);
 this.currentjob=selectedValue;
    console.log('Selected option:', value);
    // Handle selection change logic here
  }

  onSelectionChangescreen (value: any) {
    debugger;
  

    //const selectedValue = parseInt((value.target as HTMLSelectElement).value,10);
    const selectedValue =value.value;
    this.privilages =  this.Allpriv.filter(a=>a.screensId == selectedValue && a.jobId == this.currentjob);
 
    console.log('Selected option:', value);
    // Handle selection change logic here
  }


  ngOnInit(): void {
    this.PublicClsService.CheckQuery('privilages');
    debugger;
       //fill jobs
       this.back.jobsGetAll(1,10000,'id',undefined,undefined,undefined)
       .then((result: JobsDtoPagingResultDto) => {
         this.jobsOptions = result.result?? [];
   
       })
       .catch((error) => {
         console.error('Error fetching data:', error);
       });

      //fill screens
      this.back.privilageGetScreens()
      .then((result: ScreensDtoPagingResultDto) => {
      this.ScreensOptions = result.result?? [];

      })
      .catch((error) => {
      console.error('Error fetching data:', error);
      });

      //Privilage Types
      this.back.privilageGetAllPrivilageTypes()
      .then((result: PrivilageTypeDtoPagingResultDto) => {
      this.PrivilageTypesOptions = result.result?? [];

      })
      .catch((error) => {
      console.error('Error fetching data:', error);
      });
      
     // if ( this.Allpriv.length <= 0)
      this.fillPrivilages();

  }

  fillPrivilages(){

    this.back.privilageGetAll(1,10000,'ScreensId',undefined,undefined,undefined)
    .then((result: PrivilageDtoPagingResultDto) => {
      this.Allprivilages = result;
      this.privilages=this.Allprivilages.result  ?? [];
      this.Allpriv=this.Allprivilages.result  ?? [];

    
    this.privilages =  this.Allpriv.filter(a=>a.jobId == 0);
      
    })
    .catch((error) => {
      debugger;
      console.error('Error fetching data:', error);
    });

  }

  savePrivilage(): void {
    debugger;
    //this.privilage.riskRate= this.privilageSelectedOption?.value;
    if (this.isEditing) {
      this.back.privilageUpdate(this.privilage) .then(() => {
        this.fillPrivilages();
        this.alert( "تم التعديل بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في التعديل","warning");
      });
      

    
    } else {

      // this.newPrivilage.riskRate = this.privilage.riskRate as number;
      // this.newPrivilage.nameAr = this.privilage.nameAr;
      // this.newPrivilage.nameEn = this.privilage.nameEn;
      // this.newPrivilage.isActve = 1;
      this.back.privilageCreate(this.privilage) .then(() => {
        this.fillPrivilages();
        this.alert( "تم الاضافة بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في الاضافة","warning");
      });

    }
    this.resetForm();
  }

  editPrivilage(privilage: PrivilageDto): void {
   debugger;
    //this.privilageSelectedOption = this.privilageOptions.filter(a=>a.value == privilage.riskRate )[0];
    this.privilage = privilage;
    this.back.privilageUpdate(this.privilage) .then(() => {
     // this.fillPrivilages();
      //this.alert( "تم التعديل بنجاح","success");
    })
    .catch((error) => {
      console.error('Error fetching data:', error);
      this.alert( "يوجد مشكله في التعديل","warning");
    });
    this.isEditing = true;
  }


  deletePrivilage(privilage: PrivilageDto): void {
    debugger;
    const index = this.privilages.indexOf(privilage);
    if (index !== -1) {
      // this.privilages.splice(index, 1);
      this.back.privilageDelete(privilage?.id) .then(() => {
        this.fillPrivilages();
        this.alert( "تم الحذف بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في الحذف","warning");
      });
      // Logic to delete privilage from the backend or service
    }
  }

  resetForm(): void {
    this.privilage = new PrivilageDto();
    this.isEditing = false;
  }
}

