import { Routes } from '@angular/router';
import { NgbdpaginationBasicComponent } from './pagination/pagination.component';
import { NgbdAlertBasicComponent } from './alert/alert.component';

import { NgbdDropdownBasicComponent } from './dropdown-collapse/dropdown-collapse.component';
import { NgbdnavBasicComponent } from './nav/nav.component';
import { BadgeComponent } from './badge/badge.component';
import { NgbdButtonsComponent } from './buttons/buttons.component';
import { CardsComponent } from './card/card.component';
import { TableComponent } from './table/table.component';
import { BanksComponent } from './lookups/banks/banks.component';
import { JobsComponent } from './lookups/Jobs/Jobs.component';
import { CountriesComponent } from './lookups/countries/countries.component';
import { CurrenciesComponent } from './lookups/currencies/currencies.component';
import { IdentitySourcesComponent } from './lookups/identitySources/identitySources.component';
import { TransferPurposesComponent } from './lookups/transferPurposes/transferPurposes.component';



export const ComponentsRoutes: Routes = [
	{
		path: '',
		children: [
			{
				path: 'lookups/banks',
				component: BanksComponent
			},
			{
				path: 'lookups/jobs',
				component: JobsComponent
			},
			{
				path: 'lookups/countries',
				component: CountriesComponent
			},
			{
				path: 'lookups/currencies',
				component: CurrenciesComponent
			},
			{
				path: 'lookups/identitySources',
				component: IdentitySourcesComponent
			},
			{
				path: 'lookups/transferPurposes',
				component: TransferPurposesComponent
			},
			{
				path: 'table',
				component: TableComponent
			},
			{
				path: 'card',
				component: CardsComponent
			},
			{
				path: 'pagination',
				component: NgbdpaginationBasicComponent
			},
			{
				path: 'badges',
				component: BadgeComponent
			},
			{
				path: 'alert',
				component: NgbdAlertBasicComponent
			},
			{
				path: 'dropdown',
				component: NgbdDropdownBasicComponent
			},
			{
				path: 'nav',
				component: NgbdnavBasicComponent
			},
			{
				path: 'buttons',
				component: NgbdButtonsComponent
			}
		]
	}
];
