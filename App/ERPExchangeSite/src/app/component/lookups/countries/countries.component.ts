import { Component, OnInit, ViewChild  } from '@angular/core';
import { CountriesDto, CountriesDtoPagingResultDto } from 'src/app/services/api.service';
import { BackEndClientService } from 'src/app/services/back-end-client.service';
import { GenericAlertComponent } from '../../General/generic-alert/generic-alert.component';
import { PublicClsService } from 'src/app/services/public-cls.service';

@Component({
  selector: 'app-countries',
  templateUrl: './countries.component.html',
  styleUrls: ['./countries.component.scss']
})
export class CountriesComponent implements OnInit {
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
  countryOptions = [          // Array of options
    { value: 0, viewValue: 'Low' },
    { value: 1, viewValue: 'Meduim' },
    { value: 2, viewValue: 'Hight' }
  ];
  Allcountries:CountriesDtoPagingResultDto | undefined ;
  countries: CountriesDto[]  = [];
  country: CountriesDto = new CountriesDto()  ;

  isEditing = false;
  displayedColumns = ['nameAr', 'nameEn', 'riskRate', 'actions'];

  backend:BackEndClientService;
  constructor(public PublicClsService:PublicClsService,private back:BackEndClientService) { 
    this.backend = back;

  }

  ngOnInit(): void {
    this.PublicClsService.CheckQuery('Countries');
    this.fillCountries();
  }

  fillCountries(){

    this.back.countriesGetAll(1,100,undefined,undefined,undefined,undefined)
    .then((result: CountriesDtoPagingResultDto) => {
      this.Allcountries = result;
      this.countries=this.Allcountries.result  ?? [];
    })
    .catch((error) => {
      console.error('Error fetching data:', error);
    });

  }

  saveCountry(): void {
    debugger;
    //this.country.riskRate= this.countrySelectedOption?.value;
    if (this.isEditing) {
      this.back.countriesUpdate(this.country) .then(() => {
        this.fillCountries();
        this.alert( "تم التعديل بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في التعديل","warning");
      });
      

    
    } else {

      // this.newCountry.riskRate = this.country.riskRate as number;
      // this.newCountry.nameAr = this.country.nameAr;
      // this.newCountry.nameEn = this.country.nameEn;
      // this.newCountry.isActve = 1;
      this.back.countriesCreate(this.country) .then(() => {
        this.fillCountries();
        this.alert( "تم الاضافة بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في الاضافة","warning");
      });

    }
    this.resetForm();
  }

  editCountry(country: CountriesDto): void {
   
    //this.countrySelectedOption = this.countryOptions.filter(a=>a.value == country.riskRate )[0];
    this.country = country;

    this.isEditing = true;
  }


  deleteCountry(country: CountriesDto): void {
    debugger;
    const index = this.countries.indexOf(country);
    if (index !== -1) {
      // this.countries.splice(index, 1);
      this.back.countriesDelete(country?.id) .then(() => {
        this.fillCountries();
        this.alert( "تم الحذف بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في الحذف","warning");
      });
      // Logic to delete country from the backend or service
    }
  }

  resetForm(): void {
    this.country = new CountriesDto();
    this.isEditing = false;
  }
}

