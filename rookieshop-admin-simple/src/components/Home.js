import React, { useState, useEffect } from "react";

let interval;

export default function Home(props) {
  return (
    <div>
      Welcome, {props.bootcamp}
    </div>
  );
}
