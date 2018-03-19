import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Store } from '@ngrx/store';
import { ImageService } from '../image.service';
import { Image } from '../image';
import { ImageItemComponent } from '../image-item/image-item.component';

import { State as ImagesState, getAllImages } from '../../redux/reducers/images.reducer';

@Component({
  selector: 'image-list',
  templateUrl: './image-list.component.html',
  styleUrls: ['./image-list.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ImageListComponent implements OnInit {
  images$: Observable<Image[]>;

  constructor(private store: Store<ImagesState>) { }

  ngOnInit() {
    this.images$ = this.store.select((x) => x.images);
    this.images$.subscribe(x => console.log('output', x));

    /* this.images$ = combineLatest(
      this.store.select('images'),
      (imagesReducer: imageReducer.State) => {
        return imagesReducer.images;
      }); */
  }
}
