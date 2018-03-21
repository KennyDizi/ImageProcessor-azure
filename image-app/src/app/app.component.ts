import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';

import * as imageReducer from '../redux/reducers/images.reducer';
import * as imageActions from '../redux/actions/image.actions';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'image-app';

  constructor(private store: Store<imageReducer.State>) { }

  ngOnInit() {
    this.store.dispatch(new imageActions.LoadImagesAction());
  }
}
