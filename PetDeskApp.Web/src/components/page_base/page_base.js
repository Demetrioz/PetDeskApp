import { Box } from '@mui/material';

import Header from '../header/header';
import SideNavigation from '../side_navigation/side_navigation';

export default function PageBase(props) {
  return (
    <>
      <Header />
      <SideNavigation />
      <Box
        id='content'
        sx={{ marginTop: '64px', marginLeft: '220px', padding: '1rem' }}
      >
        {props.children}
      </Box>
    </>
  );
}
