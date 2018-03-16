import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Store } from '@ngrx/store';
import { ImageService } from '../image.service';
import { Image } from '../image';
import { ImageItemComponent } from '../image-item/image-item.component';

import * as imageReducer from '../../redux/reducers/images.reducer';

@Component({
  selector: 'image-list',
  templateUrl: './image-list.component.html',
  styleUrls: ['./image-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ImageListComponent {
  images$: Observable<Image[]>;

  constructor(private store: Store<imageReducer.State>) {
    this.images$ = store.select(imageReducer.getLoadedImages);
  }

}
