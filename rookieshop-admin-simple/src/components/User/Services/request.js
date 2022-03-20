import qs from 'qs';

import RequestService from '../../../services/request';
import EndPoints from '../../../Constants/endpoints';

export function getUserRequest(query) {
    return RequestService.axios.get(EndPoints.user, {
        params: query,
        paramsSerializer: params => qs.stringify(params),
    });
}