import React, {useEffect} from 'react';
import { Container } from 'semantic-ui-react';
import NavBar from './NavBar';
import ActivityDashboard from '../../features/activities/dashboard/AcitivtyDashboard';
import LoadingComponent from './LoadingComponent';
import { useStore } from '../stores/store';
import { observer } from 'mobx-react-lite';


function App() {
  const{activityStore} = useStore();

 //it is called automatically with each render/re-render
 //to ensure that useEffect will be called once, 
 useEffect( () => {
    activityStore.loadingActivites();
 },[activityStore]);

  if (activityStore.loadingInitial) return <LoadingComponent content="...Loading App"/>
  return (
    <>
      <NavBar />
      <Container style={{marginTop: '7em'}}>
        <ActivityDashboard />
      </Container>
      
    </>
  );
}

export default observer (App);
