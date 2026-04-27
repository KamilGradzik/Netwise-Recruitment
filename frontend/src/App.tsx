import { JSX, useState } from "react";

const App = ():JSX.Element => {
  var url:string = `${process.env.REACT_APP_API_URL}/api/cat-fact`

  const [catFact, setCatFact] = useState<string>("Click below to get random fact about cats!");
  const [firstClick, setFirstClick] = useState<boolean>(true)
  
  const getCatFact = async () => {
    setFirstClick(false);
    console.log(url);
    await fetch(url, {method:"GET"})
    .then(response => response.json())
    .then(data => {
      setCatFact(data.fact);
    })
  }

  return(
    <div className="App">
      <div className="App-main">
        <div className="content">
          <h1>Random Cat Fact!</h1>
          <p>{catFact}</p>
        </div>
        <button onClick={() => {getCatFact()}}>{firstClick ? "Get Fact" : "Get Another"}</button>
      </div>
    </div>
  );
}

export default App;
