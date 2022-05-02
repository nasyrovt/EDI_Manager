import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { FeedComponent } from './feed/feed.component';
import { ShowFeedComponent } from './feed/show-feed/show-feed.component';
import { AddEditFeedComponent } from './feed/add-edit-feed/add-edit-feed.component';

import { FeedsApiService } from './services/feeds-api.service';
import { DevelopersApiService } from 'src/app/services/developers-api.service';
import { FileMimesApiService } from 'src/app/services/file-mimes-api.service';
import { ClientsApiService } from 'src/app/services/clients-api.service';
import { FilesService } from 'src/app/services/files-api.service';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatChipsModule } from '@angular/material/chips';
import { EmailsChipComponent } from './emails-chip/emails-chip.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { ClientComponent } from './client/client.component';
import { AddEditClientComponent } from './client/add-edit-client/add-edit-client.component';
import { ShowClientComponent } from './client/show-client/show-client.component';
import { CarrierComponent } from './carrier/carrier.component';
import { DeveloperComponent } from './developer/developer.component';
import { AddEditCarrierComponent } from './carrier/add-edit-carrier/add-edit-carrier.component';
import { ShowCarrierComponent } from './carrier/show-carrier/show-carrier.component';
import { ShowDeveloperComponent } from './developer/show-developer/show-developer.component';
import { AddEditDeveloperComponent } from './developer/add-edit-developer/add-edit-developer.component';
import { AccountsComponent } from './accounts/accounts.component';
import { ShowAccountsComponent } from './accounts/show-accounts/show-accounts.component';
import { AddEditAccountsComponent } from './accounts/add-edit-accounts/add-edit-accounts.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatInputModule } from '@angular/material/input';
import { UploadFileComponent } from './upload-file/upload-file.component';
import { PlatformsComponent } from './platforms/platforms.component';
import { ShowPlatformComponent } from './platforms/show-platform/show-platform.component';
import { AddEditPlatformComponent } from './platforms/add-edit-platform/add-edit-platform.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRadioModule } from '@angular/material/radio';
import { SeriesDatePickerComponent } from './series-date-picker/series-date-picker.component';
import { MatMenuModule } from '@angular/material/menu';
import { SshKeysComponent } from './ssh-keys/ssh-keys.component';
import { ShowSshKeysComponent } from './ssh-keys/show-ssh-keys/show-ssh-keys.component';
import { AddEditSshKeysComponent } from './ssh-keys/add-edit-ssh-keys/add-edit-ssh-keys.component';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { JwtModule } from '@auth0/angular-jwt';
import { HomePageComponent } from './home-page/home-page.component';
import { AuthGuard } from './services/auth-guard.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { OrderModule } from 'ngx-order-pipe';
import { FilterPipeModule } from 'ngx-filter-pipe';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    FeedComponent,
    ShowFeedComponent,
    AddEditFeedComponent,
    EmailsChipComponent,
    ClientComponent,
    AddEditClientComponent,
    ShowClientComponent,
    CarrierComponent,
    DeveloperComponent,
    AddEditCarrierComponent,
    ShowCarrierComponent,
    ShowDeveloperComponent,
    AddEditDeveloperComponent,
    AccountsComponent,
    ShowAccountsComponent,
    AddEditAccountsComponent,
    UploadFileComponent,
    PlatformsComponent,
    ShowPlatformComponent,
    AddEditPlatformComponent,
    SeriesDatePickerComponent,
    SshKeysComponent,
    ShowSshKeysComponent,
    AddEditSshKeysComponent,
    LoginComponent,
    HomePageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    OrderModule,
    FilterPipeModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatChipsModule,
    MatMenuModule,
    MatProgressSpinnerModule,
    MatIconModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatCheckboxModule,
    NgbModule,
    MatRadioModule,
    BsDatepickerModule.forRoot(),
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent },
      { path: 'home', component: HomePageComponent, canActivate: [AuthGuard] }
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7255"],
        disallowedRoutes: []
      }
    }),
    NgbModule
  ],
  providers: [FeedsApiService, FilesService, ClientsApiService, FileMimesApiService, DevelopersApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
