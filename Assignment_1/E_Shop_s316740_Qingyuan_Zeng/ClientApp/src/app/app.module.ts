import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
// to submit the form and get the data of the form
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';



import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ItemCardComponent } from './item-card/item-card.component';
import { ItemListComponent } from './item-list/item-list.component';
import { EshoppingService } from './services/eshopping.service';
import { AddItemComponent } from './add-item/add-item.component';
import { ItemDetailComponent } from './item-detail/item-detail.component';
import { IdentityRegisterComponent } from './identity/identity-register/identity-register.component';
import { IdentityLoginComponent } from './identity/identity-login/identity-login.component';
const appRoutes: Routes = [
  //assign a path to the component 
  { path: 'add-item', component: AddItemComponent },
  
  { path: 'selling-items', component: ItemListComponent },
  // '/:id' allows passing a value into the url
  { path: 'item-detail/:id', component: ItemDetailComponent },
  
  { path: 'identity/login', component: IdentityLoginComponent },
  { path: 'identity/register', component: IdentityRegisterComponent },
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  // when wrong url is entered, jump back to the "selling items" page
  { path: '**', component: ItemListComponent },
 

]
@NgModule({
  //register components here
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ItemCardComponent,
    ItemListComponent,
    AddItemComponent,
    ItemDetailComponent,
    IdentityLoginComponent,
    IdentityRegisterComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    //let the application know the routes exist
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    
    EshoppingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
