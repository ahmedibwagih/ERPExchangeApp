import { Component, OnInit, ViewChild  } from '@angular/core';
import { BanksDto, BanksDtoPagingResultDto } from 'src/app/services/api.service';
import { BackEndClientService } from 'src/app/services/back-end-client.service';
import { GenericAlertComponent } from '../../General/generic-alert/generic-alert.component';

@Component({
  selector: 'app-banks',
  templateUrl: './banks.component.html',
  styleUrls: ['./banks.component.scss']
})
export class BanksComponent implements OnInit {
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
  bankOptions = [          // Array of options
    { value: 0, viewValue: 'Low' },
    { value: 1, viewValue: 'Meduim' },
    { value: 2, viewValue: 'Hight' }
  ];
  Allbanks:BanksDtoPagingResultDto | undefined ;
  banks: BanksDto[]  = [];
  bank: BanksDto = new BanksDto()  ;

  isEditing = false;
  displayedColumns = ['nameAr', 'nameEn', 'riskRate', 'actions'];

  backend:BackEndClientService;
  constructor(private back:BackEndClientService) { 
    this.backend = back;

  }

  ngOnInit(): void {
    this.fillBanks();
  }

  fillBanks(){

    this.back.banksGetAll(1,100,undefined,undefined,undefined,undefined)
    .then((result: BanksDtoPagingResultDto) => {
      this.Allbanks = result;
      this.banks=this.Allbanks.result  ?? [];
    })
    .catch((error) => {
      console.error('Error fetching data:', error);
    });

  }

  saveBank(): void {
    debugger;
    //this.bank.riskRate= this.bankSelectedOption?.value;
    if (this.isEditing) {
      this.back.banksUpdate(this.bank) .then(() => {
        this.fillBanks();
        this.alert( "تم التعديل بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في التعديل","warning");
      });
      

    
    } else {

      // this.newBank.riskRate = this.bank.riskRate as number;
      // this.newBank.nameAr = this.bank.nameAr;
      // this.newBank.nameEn = this.bank.nameEn;
      // this.newBank.isActve = 1;
      this.back.banksCreate(this.bank) .then(() => {
        this.fillBanks();
        this.alert( "تم الاضافة بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في الاضافة","warning");
      });

    }
    this.resetForm();
  }

  editBank(bank: BanksDto): void {
   
    //this.bankSelectedOption = this.bankOptions.filter(a=>a.value == bank.riskRate )[0];
    this.bank = bank;

    this.isEditing = true;
  }


  deleteBank(bank: BanksDto): void {
    debugger;
    const index = this.banks.indexOf(bank);
    if (index !== -1) {
      // this.banks.splice(index, 1);
      this.back.banksDelete(bank?.id) .then(() => {
        this.fillBanks();
        this.alert( "تم الحذف بنجاح","success");
      })
      .catch((error) => {
        console.error('Error fetching data:', error);
        this.alert( "يوجد مشكله في الحذف","warning");
      });
      // Logic to delete bank from the backend or service
    }
  }

  resetForm(): void {
    this.bank = new BanksDto();
    this.isEditing = false;
  }
}

