import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
// to submit the form and get the data of the form
import { FormsModule } from '@angular/forms';

import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Routes, RouterModule } from '@angular/router';



import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { ItemCardComponent } from './item-card/item-card.component';
import { ItemListComponent } from './item-list/item-list.component';
import { EshoppingService } from './services/eshopping.service';
import { AddItemComponent } from './add-item/add-item.component';
import { ItemDetailComponent } from './item-detail/item-detail.component';
const appRoutes: Routes = [
  //assign a path to the component 
  { path: 'add-item', component: AddItemComponent },
  { path: 'selling-items', component: ItemListComponent },
  // '/:id' allows passing a value into the url
  { path: 'item-detail/:id', component: ItemDetailComponent },
  // when wrong url is entered, jump back to the "selling items" page
  { path: '**', component: ItemListComponent },
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent, canActivate: [AuthorizeGuard] }

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
    ItemDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    //let the application know the routes exist
    RouterModule.forRoot(appRoutes),
    FormsModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    EshoppingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
