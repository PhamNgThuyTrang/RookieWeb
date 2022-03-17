import React, { useState, useEffect } from "react";
import userService from '../../services/userService';

export function Signout() {
  
  useEffect(() => {
      userService.Signout();
  });

  return(<></>);

}