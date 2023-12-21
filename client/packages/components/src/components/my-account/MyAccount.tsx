import { PortalService, PortalWidgetProps, useCurrentUser, usePortalServices } from '@portal/core';
import { getAccountTypeColor } from '@portal/ui';

import { SideSheet } from '@equinor/fusion-react-side-sheet';

import { ProfileCardHeader } from './components/ProfileCardHeader';

import { ProfileContactDetails } from './components/ProfileContactDetails';
import { Divider, Icon } from '@equinor/eds-core-react';
import { ProfileManagerCard } from './components/ProfileManager';
import { briefcase, settings, verified_user } from '@equinor/eds-icons';
import styled from 'styled-components';
import { tokens } from '@equinor/eds-tokens';
import { MyRolesTab } from '../my-roles-tab/MyRolesTab';
import { MyAllocationTab } from '../my-allocations-tab/MyAllocationTab';
import { PortalSettingsTab } from '../portal-settings-tab/PortalSettingsTab';

const Style = {
	Wrapper: styled.div`
		padding: 1rem 0rem;
		display: flex;
		flex-direction: column;
		align-items: flex-start;
	`,
	Button: styled.button`
		width: 100%;
		display: flex;
		padding: 1rem;
		height: auto;
		gap: 1rem;
		align-items: center;
		background: none;
		border: 1px solid transparent;
		color: ${tokens.colors.interactive.primary__resting.hex};
		font-weight: 500;
		line-height: 1.143em;
		text-align: center;
		:hover {
			background: var(--eds_interactive_primary__hover_alt, rgba(222, 237, 238, 1));
			color: var(--eds_interactive_primary__hover, rgba(0, 79, 85, 1));
			border: 1px solid transparent;
			border-radius: var(--eds_button__radius, 4px);
		}
		:focus-visible {
			outline: 2px dashed rgba(0, 112, 121, 1);
			outline-offset: 3px;
		}
	`,
};

export const portalWidgets: PortalService[] = [
	{
		type: 'PortalReactComponent',
		name: 'My Account',
		id: 'profile',
		component: MyAccount,
	},
	{
		type: 'PortalReactComponent',
		name: 'My Allocations',
		id: 'myAllocations',
		component: MyAllocation,
	},
	{
		type: 'PortalReactComponent',
		name: 'My Roles',
		id: 'myRoles',
		component: MyRoles,
	},
	{
		type: 'PortalReactComponent',
		name: 'Portal Settings',
		id: 'portalSettings',
		component: PortalSettings,
	},
];

export function MyAccount({ widget, onClose, open }: PortalWidgetProps) {
	const { data: user, isLoading } = useCurrentUser();

	const { setActivePortalWidgetById } = usePortalServices();

	return (
		<SideSheet isOpen={open} onClose={onClose} isDismissable={true} minWidth={widget?.minWidth}>
			<SideSheet.Indicator color={getAccountTypeColor(user?.accountType)} />
			<SideSheet.Title title={'My Account'} />
			<SideSheet.SubTitle subTitle={user?.accountType || ''} />
			<SideSheet.Content>
				<ProfileCardHeader user={user} />
				<hr />

				<ProfileContactDetails user={user} isLoading={isLoading} />
				<hr />
				<ProfileManagerCard user={user} />
				<hr />
				<Style.Wrapper>
					<Style.Button onClick={() => setActivePortalWidgetById('myAllocations')}>
						<Icon data={briefcase} scale={40} color={tokens.colors.text.static_icons__tertiary.hex} />
						My Allocations
					</Style.Button>
					<Style.Button onClick={() => setActivePortalWidgetById('myRoles')}>
						<Icon data={verified_user} scale={40} color={tokens.colors.text.static_icons__tertiary.hex} />
						My Roles
					</Style.Button>
				</Style.Wrapper>
				<hr />
				<Style.Wrapper>
					<Style.Button onClick={() => setActivePortalWidgetById('portalSettings')}>
						<Icon data={settings} scale={40} color={tokens.colors.text.static_icons__tertiary.hex} />
						Portal Setting
					</Style.Button>
				</Style.Wrapper>
			</SideSheet.Content>
		</SideSheet>
	);
}
export function MyRoles({ widget, onClose, open }: PortalWidgetProps) {
	const { data: user } = useCurrentUser();

	const { setActivePortalWidgetById } = usePortalServices();

	return (
		<SideSheet isOpen={open} onClose={onClose} isDismissable={true} minWidth={widget.minWidth}>
			<SideSheet.Indicator color={getAccountTypeColor(user?.accountType)} />
			<SideSheet.Title title={'My Roles'} />
			<SideSheet.SubTitle subTitle={user?.accountType || ''} />
			<SideSheet.Content>
				<ProfileCardHeader user={user} />
				<Divider />
				<MyRolesTab onClick={() => setActivePortalWidgetById('profile')} userRoles={user?.roles} />,
			</SideSheet.Content>
		</SideSheet>
	);
}
export function MyAllocation({ widget, onClose, open }: PortalWidgetProps) {
	const { data: user } = useCurrentUser();

	const { setActivePortalWidgetById } = usePortalServices();

	return (
		<SideSheet isOpen={open} onClose={onClose} isDismissable={true} minWidth={widget.minWidth}>
			<SideSheet.Indicator color={getAccountTypeColor(user?.accountType)} />
			<SideSheet.Title title={widget.name} />
			<SideSheet.SubTitle subTitle={user?.accountType || ''} />
			<SideSheet.Content>
				<ProfileCardHeader user={user} />
				<Divider />
				<MyAllocationTab onClick={() => setActivePortalWidgetById('profile')} positions={user?.positions} />,
			</SideSheet.Content>
		</SideSheet>
	);
}

export function PortalSettings({ widget, onClose, open }: PortalWidgetProps) {
	const { data: user } = useCurrentUser();

	const { setActivePortalWidgetById } = usePortalServices();

	return (
		<SideSheet isOpen={open} onClose={onClose} isDismissable={true} minWidth={widget.minWidth}>
			<SideSheet.Indicator color={getAccountTypeColor(user?.accountType)} />
			<SideSheet.Title title={widget.name} />
			<SideSheet.SubTitle subTitle={user?.accountType || ''} />
			<SideSheet.Content>
				<ProfileCardHeader user={user} />
				<Divider />
				<PortalSettingsTab onClick={() => setActivePortalWidgetById('profile')} user={user} />,
			</SideSheet.Content>
		</SideSheet>
	);
}
