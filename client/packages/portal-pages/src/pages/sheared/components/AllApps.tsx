import styled from 'styled-components';
import { AppContextMessage, AppGroup } from '@portal/components';
import { appGroupArraySort, useApps } from '@portal/core';

import { ProgressLoader } from '@equinor/portal-ui';
import { useTelemetry } from '@portal/core';

const Styles = {
	Wrapper: styled.div`
		column-count: 3;
		max-width: calc(100vw - 490px);

		gap: 1.5rem;

		@media only screen and (max-width: 1500px) {
			column-count: 2;
		}
		@media only screen and (max-width: 1200px) {
			column-count: 1;
		}
	`,
	WrapperLoading: styled.div`
		height: 100%;
		min-height: 10rem;
		display: flex;
		align-items: center;
		justify-content: center;
	`,
};

export const AllApps = () => {
	const { addFavorite, appGroups, isLoading } = useApps();
	const { dispatchEvent } = useTelemetry();
	// Todo Create skeletons for loading
	if (isLoading) {
		return (
			<Styles.WrapperLoading>
				<ProgressLoader title="Loading Apps" />
			</Styles.WrapperLoading>
		);
	}

	return (
		<>
			<AppContextMessage />
			<Styles.Wrapper>
				{appGroups &&
					appGroups.sort(appGroupArraySort).map((appGroup) => (
						<div key={appGroup.displayName}>
							<AppGroup
								dark={true}
								group={appGroup}
								onClick={(app, e) => {
									if (app.isDisabled) {
										e.preventDefault();
										return;
									}
									dispatchEvent(
										{
											name: 'onAppNavigation',
										},

										{
											appKey: app.appKey,
											isFavorite: app.isPinned,
											source: 'app-menu',
										}
									);
								}}
								onFavorite={(app) => {
									addFavorite(app.appKey);
								}}
							/>
						</div>
					))}
			</Styles.Wrapper>
		</>
	);
};
