import React, { lazy } from 'react';
import { Route, Switch } from 'react-router-dom';

import { SUBCATEGORY, CREATE_SUBCATEGORY, EDIT_SUBCATEGORY } from '../../Constants/pages';

const CreateSubCategory = lazy(() => import("./Create"));
const ListSubCategory = lazy(() => import("./List"));
const UpdateSubCategory = lazy(() => import("./Update"))

const SubCategory = () => {
    return (
        <Switch>
            <Route exact path={SUBCATEGORY}>
                <ListSubCategory />
            </Route>
            <Route exact path={CREATE_SUBCATEGORY}>
                <CreateSubCategory />
            </Route>
            <Route exact path={EDIT_SUBCATEGORY}>
                <UpdateSubCategory />
            </Route>
        </Switch>
    )
};

export default SubCategory;