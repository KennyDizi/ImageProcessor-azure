import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { CommonModule } from '@angular/common';
import { EffectsModule } from '@ngrx/effects';

import { AppComponent } from './app.component';
import { ImageListComponent } from './image-list/image-list.component';
import { ImageService } from './image.service';
import { ImageItemComponent } from './image-item/image-item.component';
import { ImageStatusComponent } from './image-status/image-status.component';
import { ImageDetailsComponent } from './image-details/image-details.component';
import { ImageEffects } from '../redux/effects/image.effects';

import { imagesReducer } from '../redux/reducers/images.reducer';

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
    StoreModule.provideStore({ images: imagesReducer }),
    EffectsModule.run(ImageEffects)
  ],
  providers: [ImageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
