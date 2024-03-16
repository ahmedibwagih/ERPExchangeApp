import { Component, OnInit, ViewChild  } from '@angular/core';
import { TransferPurposesDto, TransferPurposesDtoPagingResultDto } from 'src/app/services/api.service';
import { BackEndClientService } from 'src/app/services/back-end-client.service';
import { GenericAlertComponent } from '../../General/generic-alert/generic-alert.component';
import { PublicClsService } from 'src/app/services/public-cls.service';

@Component({
  selector: 'app-transferPurposes',
  templateUrl: './transferPurposes.component.html',
  styleUrls: ['./transferPurposes.component.scss']
})
export class TransferPurposesComponent implements OnInit {
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
  transferPurposeOptions = [          // Array of options
    { value: 0, viewValue: 'Low' },
    { value: 1, viewValue: 'Meduim' },
    { value: 2, viewValue: 'Hight' }
  ];
  AlltransferPurposes:TransferPurposesDtoPagingResultDto | undefined ;
  transferPurposes: TransferPurposesDto[]  = [];
  transferPurpose: TransferPurposesDto = new TransferPurposesDto()  ;

  isEditing = false;
  displayedColumns = ['nameAr', 'nameEn', 'riskRate', 'actions'];

  backend:BackEndClientService;
  constructor(public PublicClsService:PublicClsService,private back:BackEndClientService) { 
    this.backend = back;

  }
  ScreenName:string = "TransferPurposes";
  ngOnInit(): void {
    this.PublicClsService.CheckQuery('TransferPurposes');
    this.fillTransferPurposes();
  }

  fillTransferPurposes(){

    this.back.transferPurposesGetAll(1,10000,'id',undefined,undefined,undefined)
    .then((result: TransferPurposesDtoPagingResultDto) => {
      this.AlltransferPurposes = result;
      this.transferPurposes=this.AlltransferPurposes.result  ?? [];
    })
    .catch((error) => {
      console.error('Error fetching data:', error);
    });

  }

  async saveTransferPurpose(): Promise<void> {
    debugger;
    //this.transferPurpose.riskRate= this.transferPurposeSelectedOption?.value;
    if (this.isEditing) {
            
      if ( await this.PublicClsService.CheckeEdit(this.ScreenName)   == false)
      {
       this.alert( "لا يوجد صلاحية تعديل","warning");
       return;
      }

      this.back.transferPurposesUpdate(this.transferPurpose) .then(() => {
        this.fillTransferPurposes();
        this.alert( "تم التعديل بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في التعديل","warning");
      });
      

    
    } else {

      if ( await this.PublicClsService.CheckAdd('TransferPurposes')   == false)
   {
    this.alert( "لا يوجد صلاحية اضافة","warning");
    return;
   }
      // this.newTransferPurpose.riskRate = this.transferPurpose.riskRate as number;
      // this.newTransferPurpose.nameAr = this.transferPurpose.nameAr;
      // this.newTransferPurpose.nameEn = this.transferPurpose.nameEn;
      // this.newTransferPurpose.isActve = 1;
      this.back.transferPurposesCreate(this.transferPurpose) .then(() => {
        this.fillTransferPurposes();
        this.alert( "تم الاضافة بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في الاضافة","warning");
      });

    }
    this.resetForm();
  }

  editTransferPurpose(transferPurpose: TransferPurposesDto): void {
   
    //this.transferPurposeSelectedOption = this.transferPurposeOptions.filter(a=>a.value == transferPurpose.riskRate )[0];
    this.transferPurpose = transferPurpose;

    this.isEditing = true;
  }


  async deleteTransferPurpose(transferPurpose: TransferPurposesDto): Promise<void> {
    if ( await this.PublicClsService.CheckDelete(this.ScreenName)   == false)
    {
     this.alert( "لا يوجد صلاحية حذف","warning");
     return;
    }
    debugger;
    const index = this.transferPurposes.indexOf(transferPurpose);
    if (index !== -1) {
      // this.transferPurposes.splice(index, 1);
      this.back.transferPurposesDelete(transferPurpose?.id) .then(() => {
        this.fillTransferPurposes();
        this.alert( "تم الحذف بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في الحذف","warning");
      });
      // Logic to delete transferPurpose from the backend or service
    }
  }

  resetForm(): void {
    this.transferPurpose = new TransferPurposesDto();
    this.isEditing = false;
  }
}

