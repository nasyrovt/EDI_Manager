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
import { FileTypesApiService } from 'src/app/services/file-types-api.service';
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

@NgModule({
  declarations: [
    AppComponent,
    FeedComponent,
    ShowFeedComponent,
    AddEditFeedComponent,
    EmailsChipComponent,
    ClientComponent,
    AddEditClientComponent,
    ShowClientComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatChipsModule,
    MatIconModule
  ],
  providers: [FeedsApiService, FilesService, ClientsApiService, FileTypesApiService, DevelopersApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
