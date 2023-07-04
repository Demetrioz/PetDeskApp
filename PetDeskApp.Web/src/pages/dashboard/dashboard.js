import {
  Card,
  CardContent,
  CardHeader,
  List,
  ListItem,
  ListItemButton,
  ListItemText,
  Typography,
} from '@mui/material';

import PageBase from '../../components/page_base/page_base';

const cardStyles = {
  width: '300px',
  height: '300px',
  margin: '1rem',
};

export default function Dashboard() {
  return (
    <PageBase>
      <div style={{ display: 'flex', flexWrap: 'wrap' }}>
        <Card sx={cardStyles} variant='outlined'>
          <CardHeader
            title='Upcoming Appointments'
            subheader={new Date().toDateString()}
          />
          <CardContent>
            <List>
              <ListItem disablePadding>
                <ListItemButton>
                  <ListItemText>
                    Rufus - {new Date('2023-05-21').toDateString()}
                  </ListItemText>
                </ListItemButton>
              </ListItem>
              <ListItem disablePadding>
                <ListItemButton>
                  <ListItemText>
                    Max - {new Date('2023-05-22').toDateString()}
                  </ListItemText>
                </ListItemButton>
              </ListItem>
              <ListItem disablePadding>
                <ListItemButton>
                  <ListItemText>
                    Baxter - {new Date('2023-05-23').toDateString()}
                  </ListItemText>
                </ListItemButton>
              </ListItem>
            </List>
          </CardContent>
        </Card>

        <Card sx={cardStyles} variant='outlined'>
          <CardHeader title='New Pet Registrations' />
          <CardContent>
            <Typography>
              Chart with new pet registrations over the past 4 weeks
            </Typography>
          </CardContent>
        </Card>

        <Card sx={cardStyles} variant='outlined'>
          <CardHeader title='Upcoming PTO' />
          <CardContent>
            <List>
              <ListItem>
                <ListItemText>Bill Boberson: July 3 - July 5</ListItemText>
              </ListItem>
              <ListItem>
                <ListItemText>Julie Anderson: July 10 - July 15</ListItemText>
              </ListItem>
              <ListItem>
                <ListItemText>Kyle Upton: August 5</ListItemText>
              </ListItem>
            </List>
          </CardContent>
        </Card>
      </div>
    </PageBase>
  );
}
