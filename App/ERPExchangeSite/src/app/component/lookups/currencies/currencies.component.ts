import { Component, OnInit, ViewChild  } from '@angular/core';
import { CurrenciesDto, CurrenciesDtoPagingResultDto } from 'src/app/services/api.service';
import { BackEndClientService } from 'src/app/services/back-end-client.service';
import { GenericAlertComponent } from '../../General/generic-alert/generic-alert.component';

@Component({
  selector: 'app-currencies',
  templateUrl: './currencies.component.html',
  styleUrls: ['./currencies.component.scss']
})
export class CurrenciesComponent implements OnInit {
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
  currencyOptions = [          // Array of options
    { value: 0, viewValue: 'Low' },
    { value: 1, viewValue: 'Meduim' },
    { value: 2, viewValue: 'Hight' }
  ];
  Allcurrencies:CurrenciesDtoPagingResultDto | undefined ;
  currencies: CurrenciesDto[]  = [];
  currency: CurrenciesDto = new CurrenciesDto()  ;

  isEditing = false;
  displayedColumns = ['nameAr', 'nameEn', 'riskRate', 'actions'];

  backend:BackEndClientService;
  constructor(private back:BackEndClientService) { 
    this.backend = back;

  }

  ngOnInit(): void {
    this.fillCurrencies();
  }

  fillCurrencies(){

    this.back.currenciesGetAll(1,100,undefined,undefined,undefined,undefined)
    .then((result: CurrenciesDtoPagingResultDto) => {
      this.Allcurrencies = result;
      this.currencies=this.Allcurrencies.result  ?? [];
    })
    .catch((error) => {
      console.error('Error fetching data:', error);
    });

  }

  saveCurrency(): void {
    debugger;
    //this.currency.riskRate= this.currencySelectedOption?.value;
    if (this.isEditing) {
      this.back.currenciesUpdate(this.currency) .then(() => {
        this.fillCurrencies();
        this.alert( "تم التعديل بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في التعديل","warning");
      });
      

    
    } else {

      // this.newCurrency.riskRate = this.currency.riskRate as number;
      // this.newCurrency.nameAr = this.currency.nameAr;
      // this.newCurrency.nameEn = this.currency.nameEn;
      // this.newCurrency.isActve = 1;
      this.back.currenciesCreate(this.currency) .then(() => {
        this.fillCurrencies();
        this.alert( "تم الاضافة بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في الاضافة","warning");
      });

    }
    this.resetForm();
  }

  editCurrency(currency: CurrenciesDto): void {
   
    //this.currencySelectedOption = this.currencyOptions.filter(a=>a.value == currency.riskRate )[0];
    this.currency = currency;

    this.isEditing = true;
  }


  deleteCurrency(currency: CurrenciesDto): void {
    debugger;
    const index = this.currencies.indexOf(currency);
    if (index !== -1) {
      // this.currencies.splice(index, 1);
      this.back.currenciesDelete(currency?.id) .then(() => {
        this.fillCurrencies();
        this.alert( "تم الحذف بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في الحذف","warning");
      });
      // Logic to delete currency from the backend or service
    }
  }

  resetForm(): void {
    this.currency = new CurrenciesDto();
    this.isEditing = false;
  }
}

