import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ImageListComponent } from './image-list/image-list.component';
import { ImageService } from './image.service';
import { ImageItemComponent } from './image-item/image-item.component';
import { ImageStatusComponent } from './image-status/image-status.component';
import { ImageDetailsComponent } from './image-details/image-details.component';

@NgModule({
  declarations: [
    AppComponent,
    ImageListComponent,
    ImageItemComponent,
    ImageStatusComponent,
    ImageDetailsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
  ],
  providers: [ImageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
