import React, {useEffect, useState} from 'react';
import './App.css';
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {

 const [activities, setActivities] = useState([]);

 //it is called automatically with each render/re-render
 //to ensure that useEffect will be called once, 
 useEffect( () => {
   axios.get('http://localhost:5000/api/activities').then(response => {
     console.log(response);
     setActivities(response.data);
   })
 },[]);

  return (
    <div>
      <Header as='h3' icon='users' content='Reactivities' />
      <List>
      {activities.map((activity : any) => (
            <List.Item key={activity.id}>{activity.title} </List.Item>
          ))}
      </List>
   
 
    </div>
  );
}

export default App;
