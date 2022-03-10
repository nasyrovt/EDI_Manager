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

@NgModule({
  declarations: [
    AppComponent,
    FeedComponent,
    ShowFeedComponent,
    AddEditFeedComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [FeedsApiService, FilesService, ClientsApiService, FileTypesApiService, DevelopersApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
