import { Component, OnInit, ViewChild  } from '@angular/core';
import { CountriesDto, CurrenciesDtoPagingResultDto, IdentitySourcesDto, IdentitySourcesDtoPagingResultDto } from 'src/app/services/api.service';
import { BackEndClientService } from 'src/app/services/back-end-client.service';
import { GenericAlertComponent } from '../../General/generic-alert/generic-alert.component';
import { PublicClsService } from 'src/app/services/public-cls.service';

@Component({
  selector: 'app-identitySources',
  templateUrl: './identitySources.component.html',
  styleUrls: ['./identitySources.component.scss']
})
export class IdentitySourcesComponent implements OnInit {
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
  identitySourceOptions = [          // Array of options
    { value: 0, viewValue: 'Low' },
    { value: 1, viewValue: 'Meduim' },
    { value: 2, viewValue: 'Hight' }
  ];
  AllidentitySources:IdentitySourcesDtoPagingResultDto | undefined ;
  identitySources: IdentitySourcesDto[]  = [];
  identitySource: IdentitySourcesDto = new IdentitySourcesDto()  ;
  countriesOptions!: CountriesDto[];
  isEditing = false;
  displayedColumns = ['nameAr', 'nameEn', 'riskRate','countryId', 'actions'];

  backend:BackEndClientService;
  constructor(public PublicClsService:PublicClsService,private back:BackEndClientService) { 
    this.backend = back;

  }
  ScreenName:string = "IdentitySources";
  ngOnInit(): void {
    this.PublicClsService.CheckQuery('IdentitySources');
    this.fillIdentitySources();

    //fill countriesOptions
    this.back.countriesGetAll(1,10000,'id',undefined,undefined,undefined)
    .then((result: CurrenciesDtoPagingResultDto) => {
      this.countriesOptions = result.result?? [];

    })
    .catch((error) => {
      console.error('Error fetching data:', error);
    });
  }

  fillIdentitySources(){

    this.back.identitySourcesGetAll(1,10000,undefined,undefined,undefined,undefined)
    .then((result: IdentitySourcesDtoPagingResultDto) => {
      this.AllidentitySources = result;
      this.identitySources=this.AllidentitySources.result  ?? [];
    })
    .catch((error) => {
      console.error('Error fetching data:', error);
    });

  }

  async saveIdentitySource(): Promise<void> {
    debugger;
    //this.identitySource.riskRate= this.identitySourceSelectedOption?.value;
    if (this.isEditing) {
            
      if ( await this.PublicClsService.CheckeEdit(this.ScreenName)   == false)
      {
       this.alert( "لا يوجد صلاحية تعديل","warning");
       return;
      }
      this.back.identitySourcesUpdate(this.identitySource) .then(() => {
        this.fillIdentitySources();
        this.alert( "تم التعديل بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في التعديل","warning");
      });
      

    
    } else {

      if ( await this.PublicClsService.CheckAdd('IdentitySources')   == false)
   {
    this.alert( "لا يوجد صلاحية اضافة","warning");
    return;
   }
      // this.newIdentitySource.riskRate = this.identitySource.riskRate as number;
      // this.newIdentitySource.nameAr = this.identitySource.nameAr;
      // this.newIdentitySource.nameEn = this.identitySource.nameEn;
      // this.newIdentitySource.isActve = 1;
      this.back.identitySourcesCreate(this.identitySource) .then(() => {
        this.fillIdentitySources();
        this.alert( "تم الاضافة بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في الاضافة","warning");
      });

    }
    this.resetForm();
  }

  editIdentitySource(identitySource: IdentitySourcesDto): void {
   
    //this.identitySourceSelectedOption = this.identitySourceOptions.filter(a=>a.value == identitySource.riskRate )[0];
    this.identitySource = identitySource;

    this.isEditing = true;
  }


  async deleteIdentitySource(identitySource: IdentitySourcesDto): Promise<void> {
    if ( await this.PublicClsService.CheckDelete(this.ScreenName)   == false)
    {
     this.alert( "لا يوجد صلاحية حذف","warning");
     return;
    }
    debugger;
    const index = this.identitySources.indexOf(identitySource);
    if (index !== -1) {
      // this.identitySources.splice(index, 1);
      this.back.identitySourcesDelete(identitySource?.id) .then(() => {
        this.fillIdentitySources();
        this.alert( "تم الحذف بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في الحذف","warning");
      });
      // Logic to delete identitySource from the backend or service
    }
  }

  resetForm(): void {
    this.identitySource = new IdentitySourcesDto();
    this.isEditing = false;
  }
}

