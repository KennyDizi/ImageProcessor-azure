import { Action } from "@ngrx/store";

import { Image } from '../../app/image';

export const LOAD_IMAGES = 'LOAD_IMAGES';
export const LOAD_IMAGES_COMPLETE = 'LOAD_IMAGES_COMPLETE';
export const LOAD_IMAGES_ERROR = 'LOAD_IMAGES_ERROR';

export class LoadImagesAction implements Action {
    readonly type = LOAD_IMAGES;
};

export class LoadImagesSuccessAction implements Action {
    readonly type = LOAD_IMAGES_COMPLETE;

    constructor(public payload: Image[]) { }
}

export class LoadImagesErrorAction implements Action {
    readonly type = LOAD_IMAGES_ERROR;

    constructor(public error: any) { }
}

export type Actions = LoadImagesAction | LoadImagesSuccessAction | LoadImagesErrorAction;