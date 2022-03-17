import React, { useState, useEffect } from "react";
import userService from '../../services/userService';

export function Signin() {

  useEffect(() => {
      userService.Signin();
  });

  return(<></>);
}