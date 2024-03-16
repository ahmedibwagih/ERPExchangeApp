import { Component, OnInit, ViewChild  } from '@angular/core';
import { JobsDto, JobsDtoPagingResultDto } from 'src/app/services/api.service';
import { BackEndClientService } from 'src/app/services/back-end-client.service';
import { GenericAlertComponent } from '../../General/generic-alert/generic-alert.component';
import { PublicClsService } from 'src/app/services/public-cls.service';

@Component({
  selector: 'app-jobs',
  templateUrl: './Jobs.component.html',
  styleUrls: ['./Jobs.component.scss']
})
export class JobsComponent implements OnInit {
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
  jobOptions = [          // Array of options
    { value: 0, viewValue: 'Low' },
    { value: 1, viewValue: 'Meduim' },
    { value: 2, viewValue: 'Hight' }
  ];
  Alljobs:JobsDtoPagingResultDto | undefined ;
  jobs: JobsDto[]  = [];
  job: JobsDto = new JobsDto()  ;

  isEditing = false;
  displayedColumns = ['nameAr', 'nameEn', 'riskRate', 'actions'];

  backend:BackEndClientService;

  constructor(public PublicClsService:PublicClsService,private back:BackEndClientService) { 
    this.backend = back;

  }
  ScreenName:string = "Jobs";
  ngOnInit(): void {
    this.PublicClsService.CheckQuery('Jobs');
    this.fillJobs();
  }

  fillJobs(){

    this.back.jobsGetAll(1,10000,'id',undefined,undefined,undefined)
    .then((result: JobsDtoPagingResultDto) => {
      this.Alljobs = result;
      this.jobs=this.Alljobs.result  ?? [];
    })
    .catch((error) => {
      console.error('Error fetching data:', error);
    });

  }

  async saveJob(): Promise<void> {
    debugger;
    //this.job.riskRate= this.jobSelectedOption?.value;
    if (this.isEditing) {
            
      if ( await this.PublicClsService.CheckeEdit(this.ScreenName)   == false)
      {
       this.alert( "لا يوجد صلاحية تعديل","warning");
       return;
      }
      this.back.jobsUpdate(this.job) .then(() => {
        this.fillJobs();
        this.alert( "تم التعديل بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في التعديل","warning");
      });
      

    
    } else {

      if ( await this.PublicClsService.CheckAdd('Jobs')   == false)
   {
    this.alert( "لا يوجد صلاحية اضافة","warning");
    return;
   }
      // this.newJob.riskRate = this.job.riskRate as number;
      // this.newJob.nameAr = this.job.nameAr;
      // this.newJob.nameEn = this.job.nameEn;
      // this.newJob.isActve = 1;
      this.back.jobsCreate(this.job) .then(() => {
        this.fillJobs();
        this.alert( "تم الاضافة بنجاح","success");

       // ---------------------------
      //  this.back.privilageAutoFill ().then(() => {
      //   })
      //   .catch((error) => {
      //     console.error('Error fetching data:', error);
      //   });
        //---------------------------
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في الاضافة","warning");
      });

    }
    this.resetForm();
  }

  editJob(job: JobsDto): void {
   
    //this.jobSelectedOption = this.jobOptions.filter(a=>a.value == job.riskRate )[0];
    this.job = job;

    this.isEditing = true;
  }


  async deleteJob(job: JobsDto): Promise<void> {
    if ( await this.PublicClsService.CheckDelete(this.ScreenName)   == false)
    {
     this.alert( "لا يوجد صلاحية حذف","warning");
     return;
    }
    debugger;
    const index = this.jobs.indexOf(job);
    if (index !== -1) {
      // this.jobs.splice(index, 1);
      this.back.jobsDelete(job?.id) .then(() => {
        this.fillJobs();
        this.alert( "تم الحذف بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في الحذف","warning");
      });
      // Logic to delete job from the backend or service
    }
  }

  resetForm(): void {
    this.job = new JobsDto();
    this.isEditing = false;
  }
}

