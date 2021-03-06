import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
// to submit the form and get the data of the form
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';
// ngx-bootstrap for applying bootstrap features without using jQuery
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
// ngx module for creating tabs
import { TabsModule } from 'ngx-bootstrap/tabs';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ItemCardComponent } from './item-card/item-card.component';
import { ItemListComponent } from './item-list/item-list.component';
import { EshoppingService } from './services/eshopping.service';
import { AddItemComponent } from './add-item/add-item.component';
import { ItemDetailComponent } from './item-detail/item-detail.component';
import { IdentityRegisterComponent } from './identity/identity-register/identity-register.component';
import { IdentityLoginComponent } from './identity/identity-login/identity-login.component';
import { UserService } from './services/user.service';
import { AlertifyService } from './services/alertify.service';
import { AuthenticationService } from './services/authentication.service';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { SharingDataService } from './services/sharingData.service';
import { IdentityDetailComponent } from './identity/identity-detail/identity-detail.component';
const appRoutes: Routes = [
  //assign a path to the component
  { path: 'add-item', component: AddItemComponent },
  { path: 'account-detail', component: IdentityDetailComponent },

  { path: 'MyItems', component: ItemListComponent },
  { path: 'items-for-sale', component: ItemListComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  // '/:id' allows passing a value into the url
  { path: 'item-detail/:id', component: ItemDetailComponent },

  { path: 'identity/login', component: IdentityLoginComponent },
  { path: 'identity/register', component: IdentityRegisterComponent },
  { path: '', component: ItemListComponent, pathMatch: 'full' },
    // when wrong url is entered, jump back to the "selling items" page
  { path: '**', component: ItemListComponent },


]
@NgModule({
  //register components here
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ItemCardComponent,
    ItemListComponent,
    AddItemComponent,
    ItemDetailComponent,
    IdentityLoginComponent,
    IdentityRegisterComponent,
    FetchDataComponent,
    IdentityDetailComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    //let the application know the routes exist
    RouterModule.forRoot(appRoutes),
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot()
  ],
  providers: [

    EshoppingService,
    UserService,
    AlertifyService,
    AuthenticationService,
    SharingDataService
   
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
