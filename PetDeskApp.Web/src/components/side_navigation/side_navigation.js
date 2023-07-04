import { Box, Drawer, List, Toolbar } from '@mui/material';

import SideNavigationItem from '../side_navigation_item/side_navigation_item';

import { routes } from '../../Routes';

export default function SideNavigation() {
  return (
    <Drawer variant='permanent'>
      <Toolbar />
      <Box sx={{ minWidth: '220px' }}>
        <List>
          <SideNavigationItem destination={routes.index} text='Dashboard' />
          <SideNavigationItem
            destination={routes.appointment}
            text='Appointments'
          />
        </List>
      </Box>
    </Drawer>
  );
}
