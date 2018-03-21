
import { Injectable } from '@angular/core';
import { Observable } from "rxjs/Observable";
import { Effect, Actions } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { Image } from '../../app/image';

import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/empty';

import * as imageActions from '../actions/image.actions';
import { ImageService } from '../../app/image.service';

@Injectable()
export class ImageEffects {
    constructor(private action$: Actions, private imageService: ImageService) { }

    @Effect()
    load$: Observable<Action> = this.action$.ofType(imageActions.LOAD_IMAGES)
        .switchMap(() => {
            return this.imageService.getImages()
                .map(images => new imageActions.LoadImagesSuccessAction(images))
                .catch(error => Observable.of(new imageActions.LoadImagesErrorAction(error)));
        });

    @Effect()
    uploadFile$: Observable<Action> = this.action$.ofType(imageActions.UPLOAD_IMAGE)
        .switchMap((action) => {
            return this.imageService.uploadFile(action.payload)
                .map(((image: Image) => new imageActions.UploadImageSucessAction(image)))
                .catch(error => Observable.of(new imageActions.UploadImageErrorAction(error)));
        });
}