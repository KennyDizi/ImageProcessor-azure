
import { Injectable } from '@angular/core';
import { Observable } from "rxjs/Observable";
import { Effect, Actions } from '@ngrx/effects';
import { Action } from '@ngrx/store';

import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { of } from 'rxjs/observable/of';

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
                .catch(error => of(new imageActions.LoadImagesErrorAction(error)));
        });
}