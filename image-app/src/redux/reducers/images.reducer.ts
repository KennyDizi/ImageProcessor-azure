
import { ActionReducer, Action } from '@ngrx/store';
import { createSelector } from 'reselect';
import { Image } from '../../app/image';
import * as imageActions  from '../actions/image.actions';

export interface State {
    images: Image[]
};

export const initialState: State = {
    images: []
}

export function imagesReducer(state = initialState, action: imageActions.Actions): State {
    switch (action.type) {
        case imageActions.LOAD_IMAGES_COMPLETE:
            state = Object.assign({}, state, {
                images: action.payload
            });
    }

    return state;
}

export const getImagesState = (state: State) => state;
export const getLoadedImages = createSelector(getImagesState, (imageState: State) => imageState.images);