import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FeedComponent } from './feed/feed.component';
import { ShowFeedComponent } from './feed/show-feed/show-feed.component';
import { AddEditFeedComponent } from './feed/add-edit-feed/add-edit-feed.component';
import { FeedsApiService } from './feeds-api.service';

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
  providers: [FeedsApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
