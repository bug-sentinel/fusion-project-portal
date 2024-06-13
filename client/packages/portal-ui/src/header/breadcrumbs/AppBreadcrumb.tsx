import { Icon, Menu } from '@equinor/eds-core-react';
import { AppCategory, useTelemetry } from '@portal/core';
import { FC, useRef } from 'react';
import { Link, useParams } from 'react-router-dom';
import { StyledBreadcrumbItemInteract } from './styles';
import { arrow_drop_down } from '@equinor/eds-icons';

interface AppBreadcrumbProp {
	appCategory: AppCategory | undefined;
	isMenuOpen: boolean;
	setMenuOpen: React.Dispatch<React.SetStateAction<boolean>>;
}

export const AppBreadcrumb: FC<AppBreadcrumbProp> = ({ appCategory, isMenuOpen, setMenuOpen: toggleMenuOpen }) => {
	const { appKey } = useParams();
	const { dispatchEvent } = useTelemetry();

	const currentApp = appCategory?.apps.find((a) => a.key === appKey);

	const ref = useRef<HTMLSpanElement>(null);
	const hasApps = Boolean(appCategory?.apps.length);
	console.error('Apps',appCategory?.apps);
	
	return (
		<>
			{currentApp && (
				<StyledBreadcrumbItemInteract
					ref={ref}
					onClick={() => {
						toggleMenuOpen((s) => !s);
					}}
				>
					<b>{currentApp.name}</b>
					{hasApps && <Icon data={arrow_drop_down} />}
				</StyledBreadcrumbItemInteract>
			)}

			{appCategory && (
				<Menu
					open={isMenuOpen}
					placement="bottom-start"
					onMouseLeave={() => {
						toggleMenuOpen(false);						
					}}
					anchorEl={ref.current}					
				>					
					{appCategory.apps.map((app) => {
						appCategory.apps = appCategory.apps.sort((a, b) => {
							const nameA = a.name?.toUpperCase() ?? '';
							const nameB = b.name?.toUpperCase() ?? '';
							if (nameA > nameB) {
								return 1;
							}
							if (nameA < nameB) {
								return -1;
							}
							return 0;
						});	
						
						console.error('App', app.name);										
						return ( 
							<Menu.Item
								as={Link}
								key={app.key}
								to={`/apps/${app.key}/`}
								onClick={() => {
									toggleMenuOpen(false);
									dispatchEvent(
										{
											name: 'onAppNavigation',
										},
										{ appKey: app.key, source: 'top-bar-navigation' }
									);
								}}								
							>
								{currentApp?.key === app.key ? <b>{app.name}</b> : app.name}								
							</Menu.Item>						
						);	
					})}
				</Menu>
			)}
		</>
	);
};
