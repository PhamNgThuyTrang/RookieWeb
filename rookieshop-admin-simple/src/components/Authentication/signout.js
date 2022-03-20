import React, { useState, useEffect } from "react";
import userService from '../../services/userService';
import {useCookies} from 'react-cookie'

export function Signout() {

  const [cookies, removeCookie] = useCookies(['Token']);

  useEffect(() => {
    removeCookie('Token');
    userService.Signout();
  });

  return(<></>);

}